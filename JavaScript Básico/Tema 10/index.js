import * as math from "./modules/controller.js";
import chalk from "chalk";

const a = 5;
const b = 7;
const sum = math.add(a, b);
console.log(`${a} + ${b} = ${sum}`);

const multiplication = math.multiply(a, b);
console.log(chalk.green(`${a} * ${b} = ${multiplication}`));