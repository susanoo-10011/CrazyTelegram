import { useEffect, useState } from "react";

import styles from "./Message.module.scss";

import axios from "axios";

type MessageType = {
  id: string;
  userid: string;
  text: string;
  time: Date;
  replyId: string;
};

type MessageParamsType = {
  message: MessageType;
  own?: boolean;
  type?: "top" | "middle" | "bottom" | "single";
};

type UserType = {
  id: string;
  name: string;
  imgUrl: string;
};

export function Message({
  message,
  own = false,
  type = "single",
}: MessageParamsType) {
  const [user, setUser] = useState<UserType>({
    id: "0",
    name: "Username",
    imgUrl: "",
  });

  useEffect(() => {
    async function fetchUser(id: string) {
      try {
        // const res = await axios.get("");
        // if (res.status === 200) {
        //   setUser(res.data);
        // }
      } catch (error: unknown) {
        if (error instanceof Error) {
          console.log(error.message);
        } else {
          console.log("Unknown error while fetching user.");
        }
      }
    }

    fetchUser(message.id);
  }, [message.id]);

  return (
    <>
      {user && (
        <div
          className={`${styles.message} ${own ? styles.right : styles.left}
           ${styles[type]}`}
        >
          {!own && (type === "bottom" || type === "single") && (
            <img
              className={styles.pfp}
              src="https://img.freepik.com/free-vector/dark-black-background-design-with-stripes_1017-38064.jpg"
              alt=""
            />
          )}

          <div className={`${styles.content}`}>
            {!own && type === "top" && (
              <div className={styles.first_row}>
                <div className={styles.name}>{user.name}</div>
                <button className={styles.reply}>Reply</button>
              </div>
            )}
            <div className={styles.text}>{message.text}</div>
            <div className={styles.time}>{formatTime(message.time)}</div>
            {(type === "bottom" || type === "single") && (
              <div className={styles.tail}></div>
            )}
          </div>
        </div>
      )}
    </>
  );
}

function formatTime(time: Date): string {
  let hours = time.getHours();
  let minutes: number | string = time.getMinutes();

  const ampm = hours >= 12 ? "PM" : "AM";

  hours = hours % 12;
  hours = hours ? hours : 12;

  minutes = minutes < 10 ? "0" + minutes : minutes;
  const timeString = `${hours}:${minutes} ${ampm}`;

  return timeString;
}
