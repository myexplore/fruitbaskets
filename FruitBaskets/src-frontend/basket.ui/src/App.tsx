import React from 'react';
import logo from './logo.svg';
import './App.css';
import { Home } from './Home';
import { HeaderStripe as Header } from './components/HeaderStripe';
import { FruitStripe } from './components/FruitStripe';

function App() {
  return (
    <div className="App">
     <Header/>
     <FruitStripe searchBar=<h1></h1> icon="aa" signin=<h1></h1>></FruitStripe>
    </div>
  );
}

export default App;
