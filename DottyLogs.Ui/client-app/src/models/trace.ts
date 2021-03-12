import Span from "../models/span";

export default class Trace {
    requestUrl: string;
    traceIdentifier: string;
    topSpan: Span;
    inProgress: boolean;
    runningSpansCount: number;

    constructor(topSpan: Span, requestUrl: string, traceIdentifier: string) {
        this.requestUrl = requestUrl;
        this.traceIdentifier = traceIdentifier;
        this.topSpan = topSpan;
        this.inProgress = true;
        this.runningSpansCount = 1;
    }
}