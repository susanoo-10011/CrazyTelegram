

using CrazyTelegram.DataAccess.Postgres;

public class UsersRepository
{
    public UsersRepository(CrazyTelegramDbContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }
    public async Task Add(User user)
    {
        var userEntity = new UserEntity()
        {
            Id = user.Id,
            FirstName = user.FirstName,
            LastName = user.LastName,
            Email = user.Email,

        };

        await _context.Users.AddAsync(userEntity);
        await _context.SaveChangesAsync();
    }


    public async Task<User> GetByEmail(string email)
    {
        var userEntity = await -context.Users
            .AsNoTracking()
            .FirstOrDefaultAsync(u => u.Email == email) ?? throw new Exception();
        return _mapper.Map<User>(userEntity);
    }

}