import React from "react";
import {AccountHistoryInput} from "./AccountHistoryInput";

it("AccountHistoryInput Renders Correctly", () => {
    const wrapper = shallow(
        <AccountHistoryInput />
    );

    expect(wrapper).toMatchSnapshot();
});