import { ReactNode } from "react"
import  style from './styles/FruitStripe.module.css'

export function FruitStripe(props:FruitStripeProps)
{

    return (<div className={style['fruitstripe-container']}>
        {props.icon?<div className={style['fruitstripe-container-item_icon']}>image</div>:""}
        {props.searchBar?<div className={style['fruitstripe-container-item_search']}>Search Bar</div>:""}
        {props.signin?<div className={style['fruitstripe-container-item_signin']}>Sign In Testing</div>:""}
    </div>)
}
export type FruitStripeProps={
    icon:string|undefined,
searchBar:ReactNode|undefined,
signin:ReactNode|undefined
}