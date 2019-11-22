import React from "react";
import {MiscAssetInput} from "./MiscAssetInput";

it("AccountHistoryInput Renders Correctly", () => {
    const wrapper = shallow(
        <MiscAssetInput />
    );

    expect(wrapper).toMatchSnapshot();
});