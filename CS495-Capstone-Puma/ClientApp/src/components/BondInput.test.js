import {BondInput} from "./BondInput"
import React from "react";
it("Testing Jest", () => {
    expect(1+1).toEqual(2);
});

it("Testing Jest 2", () => {
    expect(2+2===4).toEqual(true);
});

it("BondInput Renders Correctly", () => {
    const wrapper = shallow(
        <BondInput />
    );
    
    expect(wrapper).toMatchSnapshot();
});