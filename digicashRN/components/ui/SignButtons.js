import React from "react";
import { Pressable, View, Text, StyleSheet } from "react-native";
import { GlobalStyles, styles } from "../../constants/style";


function SignButtons(style , onPress , text){
    return(
        <View style = {style}>
            <Pressable onPress={onPress} style = {({pressed}) => pressed && buttonStyles.pressed}></Pressable>
                <View style = {[buttonStyles.button , mode === 'flat' && buttonStyles.flat]}>
                    <Text style = {[buttonStyles.buttonText,mode === 'flat' && buttonStyles.flatText]}>{text}</Text>
                </View>          
        </View>
    );
}

const buttonStyles = ({
    button : {
        flex : 1,
    },
    flat:{
        backgroundColor : 'transparent',
    },
    flatText:{
        color : GlobalStyles.colors.gray700,
    },
    buttonText:{
        color: 'lime',
        textAlign : 'center'
    },
    pressed : {
        borderRadious : 4,
        opacity: 0.6
    },
});

export default SignButtons();