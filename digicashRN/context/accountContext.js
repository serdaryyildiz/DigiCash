import { createContext, useState } from "react"
export const AccountContext = createContext({
    accounts:[],
    setAccounts:(account)=>{}
});

function AccountContextProvider({children}){
    const [account,setAccount] = useState([]);
    
    function setAccounts(account){
        setAccount(account);
    }

    const value = {
        accounts:account,
        setAccounts:setAccounts
    }
    
    return(
        <AccountContext.Provider value={value}>
            {children}
        </AccountContext.Provider>
    )
}
export default AccountContextProvider;