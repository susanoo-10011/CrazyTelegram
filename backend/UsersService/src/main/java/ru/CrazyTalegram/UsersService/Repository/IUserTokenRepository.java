package ru.CrazyTalegram.UsersService.Repository;

import ru.CrazyTalegram.UsersService.Model.DatabaseEntities.TokenRecord;
import org.springframework.data.jpa.repository.JpaRepository;
import ru.CrazyTalegram.UsersService.Model.DatabaseEntities.User;

import java.time.LocalDateTime;
import java.util.List;

public interface IUserTokenRepository extends JpaRepository<TokenRecord, Long> {

    void deleteByTokenValue(String token);
    List<TokenRecord> findTokensByExpirationDateLessThan(LocalDateTime expirationDate);

    TokenRecord findByTokenValue(String token);

    TokenRecord findByUser(User user);

    User findUserByTokenValue(String tokenValue);
}
