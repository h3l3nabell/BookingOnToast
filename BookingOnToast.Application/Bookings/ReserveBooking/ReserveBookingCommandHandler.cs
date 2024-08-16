using BookingOnToast.Application.Abstactions.Clock;
using BookingOnToast.Application.Abstactions.Messaging;
using BookingOnToast.Domain.Abstractions;
using BookingOnToast.Domain.Bookings;
using BookingOnToast.Domain.Listings;
using BookingOnToast.Domain.Users;

namespace BookingOnToast.Application.Bookings.ReserveBooking;

internal sealed class ReserveBookingCommandHandler : ICommandHandler<ReserveBookingCommand, Guid>
{
    private readonly IUserRepository _userRepository;
    private readonly IListingRepository _listingRepository;
    private readonly IBookingRepository _bookingRepository;
    private readonly IUnitOfWork _unitOfWork;
    private readonly PricingService _pricingService;
    private readonly IDateTimeProvider _dateTimeProvider; //For Testability - now you can mock the date & time

    public ReserveBookingCommandHandler(IUserRepository userRepository
        , IListingRepository listingRepository
        , IBookingRepository bookingRepository
        , IUnitOfWork unitOfWork
        , PricingService pricingService
        , IDateTimeProvider dateTimeProvider)
    {
        _userRepository = userRepository;
        _listingRepository = listingRepository;
        _bookingRepository = bookingRepository;
        _unitOfWork = unitOfWork;
        _pricingService = pricingService;
        _dateTimeProvider = dateTimeProvider;
    }

    public async Task<Result<Guid>> Handle(ReserveBookingCommand request, CancellationToken cancellationToken)
    {
        var user = await _userRepository.GetByIdAsync(request.UserID, cancellationToken);
        if (user is null) {
            return Result.Failure<Guid>(UserErrors.NotFound);
        }

        var listing = await _listingRepository.GetByIdAsync(request.UserID, cancellationToken);
        if (listing is null)
        {
            return Result.Failure<Guid>(ListingErrors.NotFound);
        }

        var duration = DateRange.Create(request.StartDate, request.EndDate);

        if (await _bookingRepository.IsOverlappingAsync(listing,  duration, cancellationToken))
        {
            return Result.Failure<Guid>(BookingErrors.Overlap);
        }

        var booking = Booking.Reserve(listing
            , user.Id
            , duration
            , _dateTimeProvider.UtcNow
            , _pricingService);
        if (booking is null) { return Result.Failure<Guid>(BookingErrors.NotReserved); }

        //N.B. we have a race condition because of  the overlapping check above - which will solve later...
        _bookingRepository.Add(booking);

        await _unitOfWork.SaveChangesAsync(cancellationToken);

        return booking.Id;
    }
}
