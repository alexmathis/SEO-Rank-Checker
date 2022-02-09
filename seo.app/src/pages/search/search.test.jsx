import React from "react";
import { configure, shallow } from 'enzyme';
import Adapter from '@wojtekmaj/enzyme-adapter-react-17';
import Search from './search.component';

configure({ adapter: new Adapter() });


it('expect to render the card component', () => { 
    expect(shallow(<Search/>)).toMatchSnapshot()
})