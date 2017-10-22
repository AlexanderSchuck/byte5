import React, { Component } from 'react';
 
class ToDoList extends React.Component 
{
  constructor(props, context) 
  {
    super(props, context);
 
    this.state = 
    {    
		items: []
   }
  }
  
  createTasks(item) 
  {
    return <li key={item.key}>{item.text}</li>
  }
 
  render() 
  {
    var lists = this.props.entries;
    var listEntries = lists.map(this.createTasks);
	
    return 
	(
      <ul className="theList">
          {listEntries}
      </ul>
    );
  }
};

export default ToDoList;