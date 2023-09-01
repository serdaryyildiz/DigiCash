import { useEffect } from "react";
import { View, Text , SafeAreaView , Image , Button, Pressable} from "react-native";
import ShowBalance from "../../components/main/ShowBalance";
import buton from "../../components/ui/Button"
import SignButtons from "../../components/ui/SignButtons";
import {images , styles , GlobalStyles} from "../../constants/style";
import HistoryScreen from "./HistoryScreen";

function MainScene(){

    useEffect(()=>{

    })
    return(
        <SafeAreaView>
            <View style = {styles.generalView}>
                <Image source={require("../../assets/DigiCash.png")} style = {images.imageContainer}/>
        <View> 
                <Text style = {styles.container}>Balance Wallet</Text>
                <ShowBalance/>
                <Text style = {styles.paragraph}>Transfer Buton</Text>
                <Text style = {styles.paragraph}>İşlem Geçmişi</Text>
        <View>
                <Button
                title = "İşlem Geçmişi"
                />
                    
        </View>
        </View>
            <Button title = {'serdar'} />
            </View>
                <View style = {styles.generalView}>
                    <Button title = {"buton"}/>
                </View>
        </SafeAreaView>
        
    );
}


export default MainScene;