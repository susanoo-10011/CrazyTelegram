import { useEffect, useState } from "react";

import styles from "./Message.module.scss";

import axios from "axios";

type MessageType = {
  id: string;
  userid: string;
  message: string;
  time: Date;
  replyId: string;
  own?: boolean;
  position?: "top" | "middle" | "bottom";
};

type UserType = {
  id: string;
  name: string;
  imgUrl: string;
};

export function Message({
  id,
  userId,
  message,
  time,
  replyId,
  own = false,
  position = "top",
}: MessageType) {
  const [user, setUser] = useState<UserType>({
    id: id,
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

    fetchUser(id);
  }, [id]);

  return (
    <>
      {user && (
        <div className={styles.message}>
          {!own && <img className={styles.pfp} src="" alt="" />}

          <div className={`${styles.content} ${own ? styles.right : ""}`}>
            {position === "top" && (
              <div className={styles.first_row}>
                <div className={styles.name}>{user.name}</div>
                <button className={styles.reply}>Reply</button>
              </div>
            )}
            <div className={styles.text}>{message}</div>

            <div className={styles.time}>{formatTime(time)}</div>

            <div className={styles.tail}></div>
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
