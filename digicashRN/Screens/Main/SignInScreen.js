import React from "react";
import { Text, View } from "react-native";
import {styles} from "../../constants/style";


function SignIn(){
    return(
        <View>
            <Text>Sign In</Text>
            <Button>Sign In</Button>
        </View>
    );
}

const styles = ({
    signButton : {
        margin : "center",
    },
})

export default SignIn;