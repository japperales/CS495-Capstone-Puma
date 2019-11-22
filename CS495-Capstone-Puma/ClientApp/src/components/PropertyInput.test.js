import React from 'react';
import {Propertyinput} from "./Propertyinput";

it("PropertyInput Renders Correctly", () => {
    const wrapper = shallow(
        <Propertyinput />
    );

    expect(wrapper).toMatchSnapshot();

});