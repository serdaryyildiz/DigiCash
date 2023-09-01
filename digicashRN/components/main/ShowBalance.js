import { View, Text, StyleSheet } from "react-native";
import { GlobalStyles } from "../../constants/style";

 
 function ShowBalance({amount}){
    return (
        <View>
            <View style={styles.content}>
                <View style={styles.balanceWrapper}>
                    <Text style={styles.balanceText}>Your Balance</Text>
                </View>
                <View>
                    <Text style={styles.amountText}>$36,8</Text>
                </View>
            </View>
        </View>
    )
 }

 export default ShowBalance;

 const styles = StyleSheet.create({
    content:{
        alignItems:'center',
        backgroundColor:GlobalStyles.colors.primaryMain,
        borderRadius:32,
        marginHorizontal:20,
        paddingVertical:30,
    },
    balanceWrapper:{
        justifyContent:'center'
    },
    balanceText:{
        fontSize:16
    },
    amountText:{
        fontSize:24,
        fontWeight:'bold'
    }

 })