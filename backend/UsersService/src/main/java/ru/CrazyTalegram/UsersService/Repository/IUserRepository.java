package ru.CrazyTalegram.UsersService.Repository;

import ru.CrazyTalegram.UsersService.Model.DatabaseEntities.User;
import org.springframework.data.jpa.repository.JpaRepository;

public interface IUserRepository extends JpaRepository<User, Long> {

    User findUserByEmail(String email);

    User findUserByUsername(String login);

}
