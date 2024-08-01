import axios from "axios";

export default class MainService {
  static async getApi() {
    const res = await axios.get("http://localhost:8000/api/");
    return res.data;
  }
}
