import React from "react";
import "../App.css";
import {SidebarData} from './SidebarData'


function Sidebar(){
    return(
    <div className="Sidebar" sx={{height:"100vh"}}>
        <ul className="SidebarList">
            {SidebarData.map((val, key) => {
                return( 
                <li 
                key={key} 
                id = {window.location.pathname === val.path ? "active" : ""}
                className="row" 
                onClick={() => {window.location.pathname = val.path}}>
                    <span id="title">
                        {val.title}
                    </span>
                </li>
                );
            })}
        </ul>
    </div>
    );
}

export default Sidebar

