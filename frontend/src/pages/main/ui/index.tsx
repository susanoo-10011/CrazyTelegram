import styles from "./MainPage.module.scss";
import Layout from "../../../app/layout";
import { Message } from "../../../features/message/index";

export const MainPage = () => {
  return (
    <Layout>
      <div className={styles.main}>MainPage</div>
      <Message
        id="0"
        message="ffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffff"
        time={new Date()}
        userid="0"
        replyId="0"
        own
      ></Message>
    </Layout>
  );
};
