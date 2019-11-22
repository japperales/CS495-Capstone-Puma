import React from "react";
import {MutualFundInput} from "./MutualFundInput";


it("AccountHistoryInput Renders Correctly", () => {
    const wrapper = shallow(
        <MutualFundInput />
    );

    expect(wrapper).toMatchSnapshot();
    
});