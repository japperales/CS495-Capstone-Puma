import React from 'react';
import {StockInput} from "./StockInput";


it("PersonalInput Renders Correctly", () => {
    const wrapper = shallow(
        <StockInput />
    );

    expect(wrapper).toMatchSnapshot();

});