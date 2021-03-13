import { Type } from "class-transformer";
import Span from "../models/span";
import 'reflect-metadata';

export default class Trace {
    requestUrl!: string;
    traceIdentifier!: string;

    @Type(() => Span)
    spanData!: Span;

    inProgress!: boolean;
    runningSpansCount: number;

    constructor() {
        this.runningSpansCount = 1;
    }
}