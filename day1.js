const fs = require("fs");

const calcAllFuel = (number, currentFuel) => {
  const fuel = Math.floor(number / 3) - 2;

  return fuel >= 0 ? calcAllFuel(fuel, currentFuel + fuel) : currentFuel;
};

const loopData = data => {
  let fuel = 0;

  data.map(datum => {
    const total = calcAllFuel(datum, 0);
    fuel += total;
  });

  return fuel;
};

fs.readFile(`${__dirname}/data/day1.txt`, "utf8", (err, data) => {
  if (err) {
    throw err;
  }
  const dataArray = data.split("\n").map(datum => Number(datum));

  const finalNumber = loopData(dataArray);

  console.log(finalNumber);
});
