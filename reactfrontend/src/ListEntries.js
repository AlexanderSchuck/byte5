import React, { Component } from 'react';
 
class ListEntries extends React.Component 
{
  constructor(props, context) 
  {
    super(props, context);
 
    this.createTasks = this.createTasks.bind(this);
    this.delete = this.delete.bind(this);
	
  }
  
  render() 
  {
    var _listEntries = this.props.entries;
    var listItems = _listEntries.map(this.createTasks);
 
    return 
	(
      <ul className="theList">
          {listItems}
      </ul>
    );
  }
  
  createTasks(item) 
  {
	return <li key={item.key}>{item.text}</li>
  }
  
  delete(key) 
  {
    this.props.delete(key);
  }
};
export default ListEntries;