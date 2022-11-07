import axios from "axios";
const url = "https://localhost:7243/api/customer/";
// eslint-disable-next-line import/no-anonymous-default-export
export async function GetCustomer() {
  try {
    let result = await axios.get(url+'get-all-customers');
    console.log(result);
    return result;
  } catch (error) {
    console.log(error);
  }
}