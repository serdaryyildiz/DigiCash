import { StyleSheet , Image } from "react-native";

export const GlobalStyles = {
    colors: {
      primaryMain: "#13c782",
      primary50: '#e4d9fd',
      primary100: '#c6affc',
      primary200: '#a281f0',
      primary400: '#5721d4',
      primary500: '#05ffd1ff',
      primary700: '#2d0689',
      primary800: '#200364',
      accent500: '#f7bc0c',
      error50: '#fcc4e4',
      error500: '#9b095c',
      gray500: '#39324a',
      gray700: '#221c30',
    },
  };

export const styles = StyleSheet.create({
  container : {
    fontSize: 24,
    fontStyle: "italic",
    marginBottom : 2,
    fontWeight : 'bold',
    textAlign : 'center',
  }, 

  generalView : {
    margin : 12,
  },

  paragraph: {
    fontSize: 18,
    fontWeight: 'bold',
    textAlign: 'center',
    marginTop : 8,
    marginBottom : 8,

  },
  digiCash : {
    width : 200,
    height : 150,
    alignItems : "center" 
  },
});

export const images = StyleSheet.create({
  imageContainer : {
    width : 200,
    height : 150,
    alignSelf : 'center', 
  },
});





  