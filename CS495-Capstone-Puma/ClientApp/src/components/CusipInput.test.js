import React from 'react';
import {Cusipinput} from "./CusipInput";

it("CusipInput Renders Correctly", () => {
    const wrapper = shallow(
        <Cusipinput />
    );

    expect(wrapper).toMatchSnapshot();

});