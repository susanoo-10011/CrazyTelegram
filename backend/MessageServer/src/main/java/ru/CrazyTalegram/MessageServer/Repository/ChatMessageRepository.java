package ru.CrazyTalegram.MessageServer.Repository;

import org.springframework.data.mongodb.repository.MongoRepository;
import ru.CrazyTalegram.MessageServer.Model.MongoDBEntities.ChatMessage;

import java.util.List;

public interface ChatMessageRepository extends MongoRepository<ChatMessage, String> {

    List<ChatMessage> findByChatId(String s);
}
