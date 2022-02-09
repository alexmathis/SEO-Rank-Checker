import React, { useState } from "react";
import axios from "axios";
import { useFormik } from "formik";
import { SearchContainer, ButtonsBarContainer, SearchTitle } from './search.styles';
import FormInput from "../../components/form-input/form-input.component";
import CustomButton from "../../components/custom-button/custom-button.component";





const Search = () => {
  const [result, setResult] = useState("0");

  const formik = useFormik({
    initialValues: {
      keywords: "",
      address: "",
    },
    onSubmit: (values) => {
      axios
        .get(
          `https://localhost:7133/searchranking?keywords=${values.keywords}&address=${values.address}`
        )
        .then((resp) => {
          setResult(resp.data);
        })
          .catch((error) => { 
              if (error && error.response && error.response.data) {
                setResult(error.response.data);
              } else {
                  setResult("There were issues processing your request.")
            }
        });
    },
  });

  return (
      <>
      <SearchContainer>
        <SearchTitle>Search</SearchTitle>
        <span>
          {" "}
          Enter the url you want to check the ranking for, and your keywords.
        </span>
        <form onSubmit={formik.handleSubmit}>
          <FormInput
            id="keywords"
            name="Keywords"
            type="keywords"
            label="Keywords"
            onChange={formik.handleChange}
            value={formik.values.keywords}
          />
          <FormInput
            id="address"
            name="address"
            type="address"
            label="Address"
            onChange={formik.handleChange}
            value={formik.values.address}
          />
          <ButtonsBarContainer>
            <CustomButton type="submit">CHECK RANKING</CustomButton>
          </ButtonsBarContainer>
        </form>
        <div>
          <h1>Results:</h1>
          <h3>{result}</h3>
        </div>
      </SearchContainer>
      </>
  );
};

export default Search;
