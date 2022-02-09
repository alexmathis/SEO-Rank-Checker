import React from "react";
import Header from "./header.component";
import { shallow } from "enzyme";

it("expect to render the card component", () => {
  expect(shallow(<Header />)).toMatchSnapshot();
});
