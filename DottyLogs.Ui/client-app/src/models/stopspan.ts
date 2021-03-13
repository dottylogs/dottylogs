export default class StopSpan {
    spanIdentifier: string;
    traceIdentifier: string;
    wasSuccess: boolean;
    timestamp: string;

    constructor(spanIdentifier: string, traceIdentifier: string, wasSuccess: boolean, timestamp: string) {
        this.spanIdentifier = spanIdentifier;
        this.traceIdentifier = traceIdentifier;
        this.wasSuccess = wasSuccess;
        this.timestamp = timestamp;
    }
}