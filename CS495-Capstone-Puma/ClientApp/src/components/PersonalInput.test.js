import React from 'react';
import {PersonalInput} from "./PersonalInput";

it("PersonalInput Renders Correctly", () => {
    const wrapper = shallow(
        <PersonalInput />
    );

    expect(wrapper).toMatchSnapshot();

});