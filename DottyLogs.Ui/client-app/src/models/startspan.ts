export default class StartSpan {
    tracingIdentifier: string;
    requestUpdateStatus: string;
    threadId: string;
    requestUrl: string;

    constructor(tracingIdentifier: string, requestUpdateStatus: string, threadId: string, requestUrl: string) {
        this.tracingIdentifier = tracingIdentifier;
        this.requestUpdateStatus = requestUpdateStatus;
        this.threadId = threadId;
        this.requestUrl = requestUrl;
    }
}