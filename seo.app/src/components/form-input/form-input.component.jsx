import React from "react";
import {
  GroupContainer,
  FormInputContainer,
  FormInputLabel
} from './form-input.styles';


const FormInput = ({handleChange, label, value, name, ...otherProps}) => (
    <GroupContainer>
        <FormInputContainer  onChange={handleChange} {...otherProps} />
        {
            <FormInputLabel htmlFor={name} className={`${value?.length ? 'shrink' : ''} form-input-label`}>
                {label}
            </FormInputLabel>
        }
    </GroupContainer>
)

export default FormInput;

