import React, { Component } from 'react';
import logo from './logo.jpg';
import ListEntries from './ListEntries';
import ToDoList from './ToDoList';
import './App.css';


class App extends Component 
{
  render() 
  {
    return 
	(
      <div className="App">
        <header className="App-header">         
		 <img src={logo} className="App-logo" alt="logo" />
          <h1 className="App-title">ToDo App</h1>
        </header>
		<div id="container">
        <p className="App-intro">
          Organize!
        </p>
		<div className="ToDoListMain">
        <div className="header">
          <form onSubmit={this.addItem}>
			<input ref={(a) => this._inputElement = a} 
					placeholder="enter task">
			</input>
			<button type="submit">add</button>
        </form>
        </div>
		</div>
		</div>
		<ToDoList entries={this.state.items}
					 delete={this.deleteItem}/>
      </div>
    );
  }
  
  addItem(e) 
  {
  var itemArray = this.state.items;
 
  if (this._inputElement.value !== "") 
  {
    itemArray.unshift
	(
      {
        text: this._inputElement.value,
        key: Date.now()
      }
    );
 
    this.setState(
	{
      items: itemArray
    });
 
    this._inputElement.value = "";
  }
   
  e.preventDefault();
}
}
export default App;
