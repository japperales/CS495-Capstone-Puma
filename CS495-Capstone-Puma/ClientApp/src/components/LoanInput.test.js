import React from "react";
import {LoanInput} from "./LoanInput";


it("LoanInput Renders Correctly", () => {
    const wrapper = shallow(
        <LoanInput />
    );

    expect(wrapper).toMatchSnapshot();
});