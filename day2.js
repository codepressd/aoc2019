const fs = require("fs");

const chunk = data => {
  const newArray = [];
  for (i = 0; i < data.length; i += 4) {
    newArray.push(data.slice(i, i + 4));
  }
  return newArray;
};

const calcInputs = (operation, input1, input2) => {
  switch (operation) {
    case 1:
      return input1 + input2;
    case 2:
      return input1 * input2;
    case 99:
      return "stop";
    default:
      return "wrong";
  }
};
const solveIt = data => {
  let newArray = [...data];
  const chunked = chunk(data);
  for (let b = 0; b < chunked.length; b++) {
    const [operation, input1, input2, output] = chunked[b];
    const value = calcInputs(operation, newArray[input1], newArray[input2]);
    if (value === "stop") {
      break;
    } else {
      newArray.splice(output, 1, value);
    }
  }
  return newArray;
};

fs.readFile(`${__dirname}/data/day2.txt`, "utf8", (err, data) => {
  const newData = data.split(",").map(datum => Number(datum));
  let noun;
  let verb;
  for (let i = 0; i < 100; i++) {
    for (let j = 0; j < 100; j++) {
      let newArray = [...newData];
      newArray.splice(1, 1, i);
      newArray.splice(2, 1, j);

      const finishedNumber = solveIt(newArray)[0];

      if (finishedNumber === 19690720) {
        noun = newArray[1];
        verb = newArray[2];
        break;
      }
    }
  }
  const result = 100 * noun + verb;
  console.log(result);
});
