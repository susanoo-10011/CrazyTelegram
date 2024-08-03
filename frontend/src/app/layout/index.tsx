import { Footer } from "@widgets/footer";
import { Header } from "@widgets/header";

import ILayout from "./layout.interface.ts";

const Layout = ({ children }: ILayout) => {
  return (
    <>
      <Header />
      <main>{children}</main>
      <Footer />
    </>
  );
};

export default Layout;
