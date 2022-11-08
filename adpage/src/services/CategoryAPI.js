import axios from "axios";
const url = "https://localhost:7243/api/category/";
// eslint-disable-next-line import/no-anonymous-default-export
export async function GetCategory() {
  try {
    let result = await axios.get(url+'get-all-categories');
    console.log(result);
    return result;
  } catch (error) {
    console.log(error);
  }
}

export async function AddCategory(categoryName, categoryDescription){
  try {
    let category={
      name: categoryName,
      description: categoryDescription,
      created_by: null,
      created_at: null,
      updated_at: null
    };
    let result = await axios.post(url+'add-category', category);
    console.log(result);
    return result;
  } catch (error) {
    console.log(error);
  }
}

export async function UpdateCategory(categoryName, categoryDescription, categoryID){
  try {
    let category={
      name: categoryName,
      description: categoryDescription,
      created_by: null,
      created_at: null,
      updated_at: null
    };
    let result = await axios.put(url+`update-category/${categoryID}`, category);
    console.log(result);
    return result;
  } catch (error) {
    console.log(error);
  }

}


export async function DeleteCategory(categoryID){
  try {
    let result = await axios.delete(url+`delete-category/${categoryID}`);
    console.log(result);
    return result;
  } catch (error) {
    console.log(error);
  }

}


export async function GetCategoryByID(categoryID) {
  try {
    let result = await axios.get(url+`category/${categoryID}`);
    console.log(result);
    return result;
  } catch (error) {
    console.log(error);
  }
}