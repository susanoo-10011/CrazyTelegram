package ru.CrazyTalegram.MessageServer.Model.PostgresDatabaseEntities;

import jakarta.persistence.*;
import lombok.Data;
import org.hibernate.annotations.CreationTimestamp;

import java.time.LocalDateTime;

@Data
@Entity
@Table(name = "users", schema = "auth_schema")
public class User {

    @Id
    @GeneratedValue(strategy = GenerationType.IDENTITY)
    private Long id;

    @Column(unique = true, nullable = false)
    private String email;

    @Column(nullable = false)
    private String password;

    @Column(unique = true, nullable = false)
    private String username;

    @CreationTimestamp
    @Column(name = "created_at")
    private LocalDateTime createAt;

}
