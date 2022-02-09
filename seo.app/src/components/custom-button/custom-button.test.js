import React from "react";
import CustomButton from "./custom-button.component";
import { shallow } from "enzyme";

it("expect to render the card component", () => {
  expect(shallow(<CustomButton />)).toMatchSnapshot();
});
