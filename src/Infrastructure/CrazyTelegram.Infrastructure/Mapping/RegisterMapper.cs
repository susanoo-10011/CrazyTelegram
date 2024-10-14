using CrazyTelegram.Application.DTO;
using CrazyTelegram.Core.Models;
using Mapster;

namespace CrazyTelegram.Infrastructure.Mapping
{
    public class RegisterMapper : IRegister
    {
        public void Register(TypeAdapterConfig config)
        {
            config.NewConfig<User, UserDTO>()
                .RequireDestinationMemberSource(true);

        }
    }
}
