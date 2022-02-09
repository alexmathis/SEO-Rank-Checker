import React from "react";
import FormInput from "./form-input.component";
import { shallow } from "enzyme";

it("expect to render the card component", () => {
  expect(shallow(<FormInput />)).toMatchSnapshot();
});
