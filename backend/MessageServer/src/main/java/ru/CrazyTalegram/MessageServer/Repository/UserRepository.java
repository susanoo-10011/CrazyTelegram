package ru.CrazyTalegram.MessageServer.Repository;

import org.springframework.data.mongodb.repository.MongoRepository;
import ru.CrazyTalegram.MessageServer.Model.MongoDBEntities.MongoUser;
import ru.CrazyTalegram.MessageServer.Model.MongoDBEntities.Status;

import java.util.List;

public interface UserRepository extends MongoRepository<MongoUser, String> {

    List<MongoUser> findAllByStatus(Status status);
}
