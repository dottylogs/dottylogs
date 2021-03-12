import Span from "../models/span";

export default class Trace {
    requestUrl: string;
    tracingIdentifier: string;
    topSpan: Span;
    inProgress: boolean;
    runningSpansCount: number;

    constructor(topSpan: Span, requestUrl: string, tracingIdentifier: string) {
        this.requestUrl = requestUrl;
        this.tracingIdentifier = tracingIdentifier;
        this.topSpan = topSpan;
        this.inProgress = true;
        this.runningSpansCount = 1;
    }
}