export interface AuthenticationResponse {
    isAuthSuccessful: boolean;
    error: string;
    token: string;
}