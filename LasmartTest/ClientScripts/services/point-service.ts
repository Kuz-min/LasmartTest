import { Point } from "../models";

export class PointService {

    public async getAllAsync(): Promise<Point[]> {
        return fetch('/api/points')
            .then(response => {
                if (response.ok)
                    return response.json();
                else
                    throw new Error(response.statusText);
            });
    }

    public async deleteAsync(id: number): Promise<void> {
        return fetch(`/api/points/${id}`, { method: 'DELETE' })
            .then(response => {
                if (response.ok)
                    return;
                else
                    throw new Error(response.statusText);
            });
    }

}