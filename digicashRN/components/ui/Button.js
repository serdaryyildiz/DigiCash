import { Pressable, View, Text, StyleSheet } from "react-native";
import { GlobalStyles } from "../../constants/style";

function Button({children, onPress, mode, style}) {
    return(
    <View style={style}>
        <Pressable onPress={onPress} style={({pressed}) => pressed && styles.pressed}>
            <View style={[styles.button, mode==='flat' && styles.flat]} >
                <Text style={[styles.buttonText, mode === 'flat' && styles.flatText]}>{children}</Text>
            </View>
        </Pressable>
    </View>
);}

export default Button;

const styles = StyleSheet.create({
    button:{
        padding:8,
    },
    flat:{
        backgroundColor:'transparent'
    },
    buttonText:{
        color:'white',
        textAlign:'center'
    },
    flatText:{
        color:GlobalStyles.colors.primary200
    },
    pressed:{
        borderRadius:4,
        opacity:0.4
    }
});