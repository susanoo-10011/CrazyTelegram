package ru.CrazyTalegram.MessageServer.Service;

import lombok.RequiredArgsConstructor;
import org.springframework.stereotype.Service;
import ru.CrazyTalegram.MessageServer.Model.MongoDBEntities.*;
import ru.CrazyTalegram.MessageServer.Repository.UserRepository;

import java.util.List;

@Service
@RequiredArgsConstructor
public class UserService {

    private final UserRepository _userRepository;

    public void saveUser(MongoUser user) {

        user.setStatus(Status.ONLINE);
        _userRepository.save(user);

    }

    public void disconnect(MongoUser user) {

        var storedUser = _userRepository.findById(user.getId())
                .orElse(null);

        if(storedUser != null) {
            storedUser.setStatus(Status.OFFLINE);
            _userRepository.save(storedUser);
        }
    }

    public List<MongoUser> findConnectUsers() {

        return _userRepository.findAllByStatus(Status.ONLINE);
    }

}
