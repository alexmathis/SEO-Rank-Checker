import styled, {css} from 'styled-components';



export const HeaderContainer = styled.div`
    height: 70px;
    width: 100%;
    display: flex;
    justify-content: space-between;
    margin-bottom: 25px;
    background-color:black;

    @media screen and (max-width: 800px){
        height: 60px;
        padding: 10px;
        margin-bottom:20px;
    }
`;
export const Title = styled.h1`
    color: white;
`

