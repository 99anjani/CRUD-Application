import React, { useState, useEffect, Fragment } from "react";

const CRUD = () => {
  //damy-data
  const empData = [
    {
      id: 1,
      name: "Nethmi",
      age: 24,
      isActive: 1,
    },
    {
      id: 2,
      name: "Anjani",
      age: 20,
      isActive: 1,
    },
    {
      id: 3,
      name: "Gunarathne",
      age: 29,
      isActive: 0,
    },
  ];

  const [data, setData] = useEffect([]);
  useEffect(() => {
    setData(empData);
  }, []);

  return <Fragment></Fragment>;
};
export default CRUD;
